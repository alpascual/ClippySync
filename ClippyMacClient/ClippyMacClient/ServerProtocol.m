//
//  ServerProtocol.m
//  ClippyMacClient
//
//  Created by Albert Pascual on 12/18/12.
//  Copyright (c) 2012 Esri. All rights reserved.
//

#import "ServerProtocol.h"

#define ServerURL @"http://clippy.azurewebsites.net/sync/"

@implementation ServerProtocol

- (BOOL) serverLogin:(NSString*)username Pasword:(NSString*)pasword
{
    
#warning todo pass the server url and craete the protocol
}
- (NSString*) requestToServer:(NSString*)urlRequest
{
    NSURLRequest *request = [NSURLRequest requestWithURL:[NSURL URLWithString:urlRequest]];
    NSData *response = [NSURLConnection sendSynchronousRequest:request returningResponse:nil error:nil];    
    NSString *get = [[NSString alloc] initWithData:response encoding:NSUTF8StringEncoding];
    
    return get;
}

/*
 public bool ServerRegistration(string Username, string Password)
 {
 string sResponse = RequestToServer("Register?username=" + Encrypter.base64Encode(Username) + "&Password=" + Encrypter.base64Encode(Password) + "&Version=1");
 
 if (sResponse == "")
 return true;
 
 return false;
 }
 public bool ServerLogin(string Username, string Password)
 {
 string sResponse = RequestToServer("Login?username=" + Encrypter.base64Encode(Username) + "&Password=" + Encrypter.base64Encode(Password) + "&Version=1");
 
 return Convert.ToBoolean(sResponse);
 }
 
 public double SendTextToClipboard(string Username, string Password, string sClipboard)
 {
 string sRequestString = "SendClipboard?username=" + Encrypter.base64Encode(Username) + "&Password=" + Encrypter.base64Encode(Password) + "&Clipboard=" + Encrypter.base64Encode(sClipboard) + "&Version=1";
 string sResponse = RequestToServer(sRequestString);
 
 double SyncID = 0;
 try
 {
 Console.WriteLine("DEBUG: response: " + sResponse);
 SyncID = Convert.ToDouble(sResponse);
 }
 catch
 {
 SyncID = -1;
 }
 
 return SyncID;
 }
 
 public string GetTextFromClipboard(string Username, string Password, double SequenceNumber)
 {
 string sRequestString = "GetClipboard?username=" + Encrypter.base64Encode(Username) + "&Password=" + Encrypter.base64Encode(Password) +
 "&SequenceNumber=" + SequenceNumber + "&version=1";
 
 // Timeouts happen
 string sResponse = "";
 try
 {
 sResponse = RequestToServer(sRequestString);
 }
 catch { }
 
 
 return sResponse;
 }
 
 public string RegistrationUrl()
 {
 return Server.Url.Replace("sync/", "Account/Register");
 }
 
 private string RequestToServer(string sUrlRequest)
 {
 string sUrl = Server.Url + sUrlRequest;
 
 WebClient client = new WebClient();
 return client.DownloadString(sUrl);
 }*/

@end
