# Polly POC

POC Using Polly for http client retry policy. 

## Using Polly for retry policy

# How to run Sample

## Start both project Server & Client. You can call multiple get endpoint from client. 

- First get without any retry policy.

- Second get with Basic immedate retry policy.

- Third get with Linear 3 second wait retry policy.

- Fourth get with Exponential (2 pow to retry count) wait retry policy.

# Refearnce

## https://dotnetplaybook.com/fault-handling-with-polly-a-beginners-guide/
