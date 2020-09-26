#include <DallasTemperature.h>

const int DataPin = 9;
 
OneWire oneWireInstance(DataPin);
DallasTemperature DS18B20(&oneWireInstance);
 
DeviceAddress Area0_Address= {0x28, 0xFF, 0x5A, 0xCE, 0x01, 0x15, 0x03, 0x16};

void setup() {
  Serial.begin(9600);
  DS18B20.begin();
 
  Serial.println("Searching DS18B20 devices...");
  int amount = DS18B20.getDeviceCount();
  Serial.println("Found ");
  Serial.print(amount);
  Serial.println(" DS18B20 sensors.");
}

void loop() {

  Serial.println("Sending commands");
  DS18B20.requestTemperatures();
 
  Serial.print("Temperature Area 0: ");
  Serial.print(DS18B20.getTempC(Area0_Address));
  Serial.println(" Cº");
  
  delay(1000);
}
