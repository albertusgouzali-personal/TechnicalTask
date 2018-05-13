Assumption Made:
The median is group by the DataType, as each would have a different unit of measure, that might skewed the output calculation


Running Instructions:
Each File Type can be defined by the following format in the Appsettings.json
{
      "Prefix": "TOU",
      "FileType": "TOUFile",
      "Location": "D:\\Development\\ERM Power\\Sample files\\",
      "DevianceThresholdPercentage": "20"
    }
Prefix: This will be used to determine the prefix of the file that's going to be processed. Eg. as the file config define the Prefix of "TOU", 
the application will pick up all the files with prefix "TOU" and ending in ".csv" on the location speficied

FileType: This will be used to determine the File Type as it has been implemented on the app

Location: This configuration will be used to locate the location that will be scanned to get the file to be processed

DevianceThresholdPercentage: This value will be used as the threshold of determining outliers of values based on the median value calculated within the file

to build the exe file as this is a .net core project, use the following command from package manager console in VS 2017 if you using windows 10 64 bit:
dotnet publish -c Release -r win10-x64



