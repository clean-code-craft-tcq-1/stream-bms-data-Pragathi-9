#include <stdio.h>
#include <stdlib.h>
#include <math.h>

#define MAX_READINGS 1024

typedef enum {
  Failure,
  Success
} OperationMode;
typedef enum {
  StopData,
  SendData 
} DataTransmitMode;

extern OperationMode BMS_Readfromdatafile();
extern OperationMode BMS_WriteToConsole(DataTransmitMode UserTransmitRequest);
extern int BufferArraysize;
extern float Temperature[MAX_READINGS];
extern float ChargeRate[MAX_READINGS];
OperationMode ReadStatus, WriteStatus;

