#define MAX_READINGS 1024

typedef enum {
  Failure,
  Success
} OperationMode;
typedef enum {
  StopData,
  SendData 
} DataTransmitMode;

OperationMode BMS_Readfromdatafile();
OperationMode BMS_WriteToConsole(DataTransmitMode UserTransmitRequest);
extern int BufferArraysize;
extern float Temperature[MAX_READINGS];
extern float ChargeRate[MAX_READINGS];
OperationMode ReadStatus, WriteStatus;

