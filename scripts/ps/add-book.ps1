param(
  [Parameter(Mandatory)][string]$Title,
  [Parameter(Mandatory)][int]$AuthorId
)

$body = @{
  query = @'
mutation ($t:String!, $id:Int!){
  addBook(title:$t, authorId:$id){
    id
    title
    author { id name }
  }
}
'@
  variables = @{ t = $Title; id = $AuthorId }
} | ConvertTo-Json -Compress

Invoke-RestMethod -Uri http://localhost:61483/graphql `
                  -Method Post -ContentType "application/json" `
                  -Body $body |
ConvertTo-Json -Depth 5
