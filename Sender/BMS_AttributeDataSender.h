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
int BufferArraysize=0;
float Temperature[MAX_READINGS]={};
float ChargeRate[MAX_READINGS]={};
OperationMode ReadStatus, WriteStatus;

