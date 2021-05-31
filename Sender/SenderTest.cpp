#define CATCH_CONFIG_MAIN  // This tells Catch to provide a main() - only do this in one cpp file

#include "catch.hpp"
#include "BMS_AttributeDataSender.h"

TEST_CASE("To check if file was successfully opened to read") 
{
  REQUIRE(BMS_Readfromdatafile()== Success); 
}

TEST_CASE("To check data is printed on the console") 
{
  REQUIRE(BMS_WriteToConsole()== Success);
  
}
