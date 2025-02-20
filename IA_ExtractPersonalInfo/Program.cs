using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;
using System.Collections;
using System.IO;

string endpint = "https://xx.cognitiveservices.azure.com/";
string apiKey = "xx";

var credential = new AzureKeyCredential(apiKey);

var client = new DocumentAnalysisClient(new Uri(endpint), credential);

Stream stream = new MemoryStream(File.ReadAllBytes(@"tempin\ci.png"));

AnalyzeDocumentOperation operation = client.AnalyzeDocument(WaitUntil.Completed, "prebuilt-idDocument", stream);

AnalyzeResult results = operation.Value;

List<string> extractValue = new List<string>();



File.WriteAllText("fileout.txt", results.Content, System.Text.Encoding.UTF8);

Console.WriteLine("");
