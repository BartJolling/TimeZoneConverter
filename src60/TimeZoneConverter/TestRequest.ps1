$uri = "https://localhost:8443/TimeZoneConverter"
$headers = @{
    "Content-Type" = "text/xml; charset=utf-8"
    "SOAPAction"   = "http://bartjolling.github.io/ITimeZoneConverter/ConvertToOffsetRequest"
}
$body = Get-Content -Raw -Path ".\TestRequest.xml"

$response = Invoke-WebRequest -Uri $uri -Method Post -Headers $headers -Body $body -SkipCertificateCheck
$response.Content
