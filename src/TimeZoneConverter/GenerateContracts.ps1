﻿$svcUtilExe = "C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\x64\SvcUtil.exe"
& $svcUtilExe "./TimeZoneConverter.wsdl" "./TimeZoneConverter.xsd" /t:code /language:"C#" /ser:XmlSerializer /syncOnly /o:ITimeZoneConverter.cs /n:"*,TimeZoneConverter" /config:"Web.config" /mergeConfig