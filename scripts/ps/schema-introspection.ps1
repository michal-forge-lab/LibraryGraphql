$body = @{
  query = @'
{
  __schema {
    queryType   { fields { name } }
    mutationType{ fields { name } }
    types       { name kind }
  }
}
'@
} | ConvertTo-Json -Compress

Invoke-RestMethod -Uri http://localhost:61483/graphql `
                  -Method Post -ContentType "application/json" `
                  -Body $body |
ConvertTo-Json -Depth 5
