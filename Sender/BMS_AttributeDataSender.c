
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include "BMS_AttributeDataSender.h"

OperationMode ReadStatus, WriteStatus;

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

	
OperationMode BMS_WriteToConsole(DataTransmitMode UserTransmitRequest)
{
	WriteStatus=Failure;
	if (UserTransmitRequest)
	{
		printf("BMS Temperature \t BMS Charge Rate");
		for(int ArrayIndex=0; ArrayIndex < BufferArraysize; ArrayIndex++)
		{
			printf("%f\t %f", Temperature[ArrayIndex],ChargeRate[ArrayIndex]);
		}
		WriteStatus= Success;
	}
	
	return WriteStatus;
}
