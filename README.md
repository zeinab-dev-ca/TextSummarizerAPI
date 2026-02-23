\# AI Text Summarizer API



A C# REST API that uses Claude AI to summarize any text instantly.



\## Features

\- REST API endpoint that accepts any text

\- Claude AI generates a 2-3 sentence summary

\- Clean web interface to test the summarizer

\- Swagger documentation for API testing

\- Built with ASP.NET Core Web API



\## Technologies Used

\- ASP.NET Core Web API (.NET 10)

\- Claude AI API (Anthropic)

\- Swagger / OpenAPI

\- Bootstrap 5

\- C#



\## How to Run

1\. Clone the repository

2\. Open in Visual Studio 2022

3\. Add your Claude API key to appsettings.json

4\. Press Ctrl+F5 to run

5\. Navigate to https://localhost:xxxx to use the web interface

6\. Or go to https://localhost:xxxx/swagger to test the API



\## API Usage

POST /api/Summary

Content-Type: application/json



{

&nbsp; "text": "Your long text here..."

}



Response:

{

&nbsp; "summary": "AI generated summary..."

}



\## Author

Zeinab | .NET Developer \& AI Integration Specialist

GitHub: zeinab-dev-ca

