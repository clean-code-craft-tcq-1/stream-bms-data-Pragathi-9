/**********************************************
             Include header files
***********************************************/
#include <stdio.h>
#include <stdlib.h>
#include <math.h>

/**********************************************
                 Macros
***********************************************/
//Maximum data that could be read from a file at one time request, its the buffer size
#define MAX_READINGS 1024  

/**********************************************
 Operation mode - Operation successful or not
 Data transmit mode- The user can ask to stop 
                     transmission on Console
***********************************************/
typedef enum {
  Failure,
  Success
} OperationMode;

typedef enum {
  StopData,
  SendData 
} DataTransmitMode;
/**********************************************
        Function Declaration
***********************************************/
extern OperationMode BMS_Readfromdatafile();
extern OperationMode BMS_WriteToConsole(DataTransmitMode UserTransmitRequest);

/**********************************************
        Variable Declaration
***********************************************/
extern int BufferArraysize;
extern float Temperature[MAX_READINGS]; //buffer to store BMS temperature value
extern float ChargeRate[MAX_READINGS];  //buffer to store BMS Charge Rate value



