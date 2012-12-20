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
@end
