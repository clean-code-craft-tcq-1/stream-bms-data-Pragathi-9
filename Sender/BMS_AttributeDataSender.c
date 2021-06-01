  
/**********************************************
Include header files
***********************************************/
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include "BMS_AttributeDataSender.h"
  
/**********************************************
Variable declaration
***********************************************/
OperationMode ReadStatus, WriteStatus;
float Temperature[]={};
float ChargeRate[]={};
int BufferArraysize=0;

/*********************************************
Function definitions
**********************************************/

/********************************************************************************
 * Function: BMS_Readfromdatafile
 
 * Description: This function reads the BMS parameter readings from the suitable 
   data log file and stores into a buffer
   
 * input: void
 
 * returns: Read status is Success(True) if the data is successfully read from the file.
 *********************************************************************************/
OperationMode BMS_Readfromdatafile()
{
  FILE *BMS_datafile;
  int line=1;
 ReadStatus= Failure;
 
	
  BMS_datafile=fopen("./Sender/BMS_attributelog.txt", "r");
  	if (BMS_datafile==NULL)
	{
		printf("File open attempt failed\n");
		
	}
	
	else
	{
		float ReadTemperature=0,ReadChargeRate=0;
		printf("File open attempt successful\n");
		int Index=0;
		while(line != EOF)
		{
			line=fscanf(BMS_datafile,"%f %f",&ReadTemperature,&ReadChargeRate);
			Temperature[Index]=ReadTemperature;
			ChargeRate[Index]=ReadChargeRate;
			Index++;
		}
		BufferArraysize=Index;
		ReadStatus= Success;
	}
	
	fclose(BMS_datafile);
	return ReadStatus;
}

/***********************************************************************************************
 * Function: BMS_WriteToConsole
 
 * Description: This function reads the BMS parameter readings from the buffer 
   and writes on to the Console window.
   
 * input: User request is input to the same. Unless user demands the start of 
 	  transmission, no data is written on to console
	  
 * returns: Write status is Success(True) if the data is successfully written to the console.
 ***********************************************************************************************/	
OperationMode BMS_WriteToConsole(DataTransmitMode UserTransmitRequest)
{
	WriteStatus=Failure;
	if (UserTransmitRequest)
	{
		printf("BMS:Temperature \t BMS: Charge Rate\n");
		for(int ArrayIndex=0; ArrayIndex < BufferArraysize; ArrayIndex++)
		{
			printf("%f\t\t %f\n", Temperature[ArrayIndex],ChargeRate[ArrayIndex]);
		}
		WriteStatus= Success;
	}
	
	return WriteStatus;
}
