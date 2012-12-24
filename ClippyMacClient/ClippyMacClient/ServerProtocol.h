//
//  ServerProtocol.h
//  ClippyMacClient
//
//  Created by Albert Pascual on 12/18/12.
//  Copyright (c) 2012 Esri. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface ServerProtocol : NSObject

- (BOOL) serverLogin:(NSString*)username Pasword:(NSString*)password;
- (BOOL) serverRegistration:(NSString *)username Password:(NSString*)password;
- (NSString*) requestToServer:(NSString*)urlRequest;

+ (NSString *)encodeBase64WithString:(NSString *)strData;

@end
