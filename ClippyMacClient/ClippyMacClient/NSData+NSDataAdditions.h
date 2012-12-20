//
//  NSData+NSDataAdditions.h
//  ClippyMacClient
//
//  Created by Albert Pascual on 12/19/12.
//  Copyright (c) 2012 Esri. All rights reserved.
//

#import <Foundation/Foundation.h>

@class NSString;

@interface NSData (NSDataAdditions)

+ (NSData *) decodingBase64DataFromString:(NSString *)string;

@end
