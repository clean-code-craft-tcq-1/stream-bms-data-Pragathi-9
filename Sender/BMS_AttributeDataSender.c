#include "BMS_AttributeDataSender.h"
#include <stdio.h>

OperationMode BMS_Readfromdatafile()
{
  FILE *BMS_datafile;
  int line=1;
 OperationMode ReadStatus= Failure;

  BMS_datafile=fopen("BMS_attributelog.txt", "r");
  if (BMS_datafile==NULL)
	{
		printf("File open attempt failed\n");
		ReadStatus = Failure;
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
		ReadStatus= Success;
	}
	
	fclose(BMS_datafile);
	return ReadStatus;
}

OperationMode BMS_WriteToConsole()
{
	OperationMode WriteStatus=Failure;
	
	if (BMS_Readfromdatafile)
	{
		printf("BMS Temperature \t BMS Charge Rate");
		for(int ArrayIndex=0; ArrayIndex< Index; ArrayIndex++)
		{
			printf("%f\t %f", Temperature[ArrayIndex],ChargeRate[ArrayIndex]);
		}
		WriteStatus= Success;
	}
	else
	{
		WriteStatus= Failure;
	}
	
	return WriteStatus;
}
