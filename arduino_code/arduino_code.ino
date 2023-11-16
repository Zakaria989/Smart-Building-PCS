#include <ArduinoJson.h>

const double REFERENCE_VOLTAGE = 5.0;

// Pin definitions
const int TMP_PIN = A0;
const int THERMISTOR_PIN = A1;
const int PHOTO_RESISTOR_PIN = A2;
const int LIGHT1_PIN = 13;
const int BUTTON1_PIN = 3;
const int POTENTIOMETER_PIN = A3;
const int LIGHT2_PIN = 4;

// Thermistor constants
const int THERMISTOR_R0 = 10000; // Reference resistance
const int THERMISTOR_RT0 = 10000; // Thermistor resistance at T0
const int THERMISTOR_B = 4050; // Beta value
const double T0 = 25 + 273.15; // T0 in Kelvin

// Time-related variables
const unsigned long DEBOUNCE_DURATION = 50; // Milliseconds

// Logic definitions
bool lightAutoOrLocal = false; 
bool lightOffOrOn = false; 


void setup() {
  Serial.begin(9600);
  pinMode(LIGHT1_PIN, OUTPUT);
  pinMode(BUTTON1_PIN, INPUT);
  pinMode(LIGHT2_PIN, OUTPUT);
  pinMode(PHOTO_RESISTOR_PIN, OUTPUT);
}

void loop() {
  // Potentiometer logic
  int potentiometerValue = map(analogRead(POTENTIOMETER_PIN), 0, 1023, 0, 255);
  int heatingPercentage = (potentiometerValue / 255.0) * 100.0;

  // Button debounce
  byte lastButton1State = LOW;
  unsigned long lastTimeButton1StateChanged = 0;
  byte buttonState1 = digitalRead(BUTTON1_PIN);

  if (millis() - lastTimeButton1StateChanged > DEBOUNCE_DURATION) {
    if (buttonState1 != lastButton1State) {
      lastButton1State = buttonState1;
      if (buttonState1 == HIGH) {
        byte led1State = (digitalRead(LIGHT1_PIN) == HIGH) ? LOW : HIGH;
        digitalWrite(LIGHT1_PIN, led1State);
      }
    }
  }

  // Photoresistor control
  if (lightAutoOrLocal == false)
  {
    if (analogRead(PHOTO_RESISTOR_PIN) <= 20) {
      digitalWrite(LIGHT2_PIN, HIGH);
    } else {
      digitalWrite(LIGHT2_PIN, LOW);
    }
  }
  else
  {
    if (lightOffOrOn == true)
    {
      digitalWrite(LIGHT2_PIN, LOW);
    }
    else
    {
      digitalWrite(LIGHT2_PIN, HIGH);
    }
  }

  // TMP 36 sensor
  int tmpSensorValue = analogRead(TMP_PIN);
  double tmpTempVoltage = (double)tmpSensorValue * (REFERENCE_VOLTAGE * 1000 / 1024);
  double tmpTemperatureC = (tmpTempVoltage - 500) / 10;

  // Thermistor sensor
  int thermistorSensorValue = analogRead(THERMISTOR_PIN);
  double thermistorV = (double)thermistorSensorValue * (REFERENCE_VOLTAGE / 1024.0);
  double thermistorVR = REFERENCE_VOLTAGE - thermistorV;
  double thermistorRT = thermistorV / (thermistorVR / THERMISTOR_R0);
  double ln = log(thermistorRT / THERMISTOR_RT0);
  double thermistorTemperatureC = 1 / ((ln / THERMISTOR_B) + (1 / T0)) - 273.15;


if (Serial.available() > 0) {
    String command = Serial.readStringUntil('\n');
    if (command == "OPEN_DOOR") 
    {
      digitalWrite(LIGHT1_PIN, HIGH); // Turn on the door light
    } 
    else if (command == "AUTO_LIGHT") 
    {
      lightAutoOrLocal = false;
    } 
    else if (command == "LOCAL_LIGHT") 
    {
      lightAutoOrLocal = true;
    }
    else if (command == "LIGHT_OFF") 
    {
      lightOffOrOn = true;
    }
    else if (command == "LIGHT_ON") 
    {
      lightOffOrOn = false;
    }
}



  // Define a JSON document
  StaticJsonDocument<256> jsonDoc;

  // Populate the JSON document with your sensor data
  jsonDoc["Temperature Inside"] = tmpTemperatureC;
  jsonDoc["Temperature Outside"] = thermistorTemperatureC;
  jsonDoc["Porch Light"] = digitalRead(LIGHT2_PIN);
  jsonDoc["Door"] = digitalRead(LIGHT1_PIN);
  jsonDoc["Light Sensor"] = analogRead(PHOTO_RESISTOR_PIN);
  jsonDoc["Heat Pump Level"] = heatingPercentage;

  // Serialize the JSON document to a string
  String jsonData;
  serializeJson(jsonDoc, jsonData);

  // Send the JSON data via Serial
  Serial.println(jsonData);


}
