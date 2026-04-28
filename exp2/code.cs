const int analogInPin_NTC = A0;

int sensorValue_NTC = 0;

float R_NTC = 0.0;
float T_celsius = 0.0;

const float R_fixed_NTC = 10000.0;
const float T0 = 298.15;
const float R0 = 100000.0;
const float B  = 3950.0;

unsigned long startTime = 0;

void setup() {
  Serial.begin(9600);
  startTime = millis();
  Serial.println("tiempo_ms,R_NTC_Ohm,T_celsius");
}

void loop() {
  sensorValue_NTC = analogRead(analogInPin_NTC);
  R_NTC = sensorValue_NTC * R_fixed_NTC / (1024.0 - sensorValue_NTC);

  float lnR = log(R_NTC / R0);
  float T_kelvin = 1.0 / ((1.0 / T0) + (lnR / B));
  T_celsius = T_kelvin - 273.15;

  unsigned long t = millis() - startTime;

  Serial.print(t);         Serial.print(",");
  Serial.print(R_NTC);     Serial.print(",");
  Serial.println(T_celsius);

  delay(1000);
}
