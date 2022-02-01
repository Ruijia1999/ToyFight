int sensorValue_p1head = 0;  // 類比輸入得到的數值
int sensorValue_p1body = 0;  // 類比輸入得到的數值
int sensorValue_p2head = 0;  // 類比輸入得到的數值
int sensorValue_p2body = 0;  // 類比輸入得到的數值
 float voltage= 0;
int p1head = A5;    //類比輸入的PIN腳
int p1body = A4;
int p2head = A1;
int p2body = A0;
int delaytime = 10;

void setup() {
  // put your setup code here, to run once:
  pinMode(7, OUTPUT);//P1
  pinMode(13, OUTPUT);//P2

  pinMode(2, OUTPUT);//low voltage P1
  pinMode(3, OUTPUT);//low voltage P1
  pinMode(10, OUTPUT);//low voltage P2
  pinMode(11, OUTPUT);//low voltage P2
  /*
  pinMode(p1head, INPUT);
  pinMode(p1body, INPUT);
  pinMode(p2head, INPUT);
  pinMode(p2body, INPUT);*/
  Serial.begin(9600);

}


void loop() {

  //analogWrite(2, 55);
  
  analogWrite(7, 255);
  ReadP2Head();
  ReadP2Body();
  
  analogWrite(13,100);
  ReadP1Head();
  ReadP1Body();
  
}

void ReadP1Head(){
  
  sensorValue_p1head =analogRead(p1head);   
  delay(delaytime);
  sensorValue_p1head =analogRead(p1head);   
  delay(delaytime);
  
  voltage= sensorValue_p1head * (5.0 / 1023.0);
  sensorValue_p1head = map(sensorValue_p1head,0,1023,0,255);
  
//Serial.println(sensorValue_p1head);
  if(sensorValue_p1head == 126 || sensorValue_p1head == 127){
    Serial.println("head_1");
  }  
}

void ReadP1Body(){

  sensorValue_p1body =analogRead(p1body);
  delay(delaytime);
  sensorValue_p1body =analogRead(p1body);
  delay(delaytime);
  
  voltage= sensorValue_p1body * (5.0 / 1023.0);
  sensorValue_p1body = map(sensorValue_p1body,0,1023,0,255);  
  

  if(sensorValue_p1body == 126 || sensorValue_p1body == 127){
    Serial.println("body_1");
  }
}

void ReadP2Head(){
  
  sensorValue_p2head =analogRead(p2head); 
  delay(delaytime);
  sensorValue_p2head =analogRead(p2head); 
  delay(delaytime);
  
  voltage= sensorValue_p2head * (5.0 / 1023.0);
  sensorValue_p2head = map(sensorValue_p2head,0,1023,0,255); 

  if(sensorValue_p2head == 126 || sensorValue_p2head == 127){
    Serial.println("head_2");
  }  
}

void ReadP2Body(){

  sensorValue_p2body =analogRead(p2body);   //讀取類比輸入的值會得到0~1023
  delay(delaytime);
  sensorValue_p2body =analogRead(p2body);
  delay(delaytime);
  
  voltage= sensorValue_p2body * (5.0 / 1023.0);
  sensorValue_p2body = map(sensorValue_p2body,0,1023,0,255);  //將0~1023轉化成0~255

  //Serial.println(sensorValue_p2body);
  
  if(sensorValue_p2body == 126 || sensorValue_p2body == 127){
    Serial.println("body_2");
  }
}
  
