$env:DOTNET_SVCUTIL_TELEMETRY_OPTOUT = "1"

Remove-Item ./Contracts/ITimeZoneConverter.cs -Force -ErrorAction SilentlyContinue

dotnet tool run dotnet-svcutil ./../../Contracts/TimeZoneConverter.wsdl ./../../Contracts/TimeZoneConverter.xsd `
  --serializer XmlSerializer `
  --outputDir ./Contracts `
  --outputFile ITimeZoneConverter.cs `
  --namespace "*,TimeZoneConverter.Contracts" `
  --targetFramework net9.0