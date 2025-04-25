$query = @'
query ($skip:Int!, $take:Int!) {
  authorsPaged(skip:$skip, take:$take) {
    totalCount
    nodes { id name }
  }
}
'@

$body = @{
  query     = $query
  variables = @{ skip = 0; take = 3 }
} | ConvertTo-Json -Compress

Invoke-RestMethod -Uri http://localhost:61483/graphql `
                  -Method Post -ContentType "application/json" `
                  -Body $body |
ConvertTo-Json -Depth 5
