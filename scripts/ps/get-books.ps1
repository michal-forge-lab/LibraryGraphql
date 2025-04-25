$body = @{
  query = @'
{
  books {
    id
    title
    author { id name }
  }
}
'@
} | ConvertTo-Json -Compress

Invoke-RestMethod -Uri http://localhost:61483/graphql `
                  -Method Post -ContentType "application/json" `
                  -Body $body |
ConvertTo-Json -Depth 5
