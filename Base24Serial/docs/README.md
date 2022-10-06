# Base24Serial
## About
The purpose of this code is providing an easy way to convert from base-16 into base-24 (5x5 format; used in many products serial numbers)

## How to use
The use is very simple:

    var hexValue = "00000111112222233333444445555566";
    var serial = Base24SerialConverter.Convert(hexValue);

The result is:

    6G8TW-3W4QT-YP8PG-7GJF8-KDYBB

This project was inspired by the articles [How to find the Windows 7 product key](https://support.lenovo.com/ee/en/solutions/ht500032) and [How to retrieve the serial number of the SQL Server instance](https://bit.ly/31KT7wb)