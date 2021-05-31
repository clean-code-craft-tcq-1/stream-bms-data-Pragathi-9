
#include <stdio.h>
#include "BMS_AttributeDataSender.h"


OperationMode ReadStatus, WriteStatus;
OperationMode BMS_Readfromdatafile()
{
  FILE *BMS_datafile;
  int line=1;
 ReadStatus= Failure;

  BMS_datafile=fopen("BMS_attributelog.txt", "r");
  	if (BMS_datafile==NULL)
	{
		printf("File open attempt failed\n");
		
	}
	
	else
	{
		printf("File open attempt successful\n");
		int Index=0;
		while(line != EOF)
		{
			line=fscanf(BMS_datafile,"%f %f",&Temperature[Index],&ChargeRate[Index]);
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
	if (ReadStatus && UserTransmitRequest)
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
