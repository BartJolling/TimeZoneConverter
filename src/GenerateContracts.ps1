﻿$svcUtilExe = "C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\x64\SvcUtil.exe"
& $svcUtilExe "TimeZoneConvertor.wsdl" "TimeZoneConvertor.xsd" /t:code /language:"C#" /syncOnly /o:ITimeZoneConvertorService.cs /n:"*,TimeZoneConvertor" /config:"Web.config" /mergeConfig