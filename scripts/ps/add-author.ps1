param(
  [Parameter(Mandatory)] [string]$Name
)

$body = @{
  query = 'mutation ($n:String!){ addAuthor(name:$n){ id name } }'
  variables = @{ n = $Name }
} | ConvertTo-Json -Compress

Invoke-RestMethod -Uri http://localhost:61483/graphql `
                  -Method Post -ContentType "application/json" `
                  -Body $body |
ConvertTo-Json -Depth 4
