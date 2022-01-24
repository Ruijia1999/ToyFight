int sensorValue = 0;
int sensorPin = A5;

void setup() {
  // put your setup code here, to run once:
  pinMode(8, OUTPUT);
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  analogWrite(8,255);
  sensorValue = analogRead(sensorPin);
  sensorValue = map(sensorValue,0,1023,0,255);
  
  if(sensorValue == 255){
    Serial.println("head");
  }

  
  delay(10);
}
