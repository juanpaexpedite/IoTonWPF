#include <OneWire.h>
#include <DallasTemperature.h>

const int DataPin = 9;

OneWire oneWireInstance(DataPin);
DallasTemperature DS18B20Sensor(&oneWireInstance);

void setup() 
{
    
    Serial.begin(9600);
    DS18B20Sensor.begin();

    Serial.println("Searching DS18B20 devices...");
    
    int amount = sensorDS18B20.getDeviceCount();
    Serial.print("Found ");
    Serial.print(amount);
    Serial.println(" DS18B20 sensors.");

    if(amount>0)
    {
        DeviceAddress sensor;
        sensorDS18B20.getAddress(sensor, 1);

        Serial.print("Sensor DS18B20 found: ");

        for (uint8_t i = 0; i < 8; i++)
        {
          if (sensor[i] < 16) 
          {
            Serial.print("0");
          }
          Serial.print(sensor[i], HEX);
        }
    }    
}

void loop() 
{

}
