//
//  LoginWindowController.h
//  ClippyMacClient
//
//  Created by Al Pascual on 12/12/12.
//  Copyright (c) 2012 Esri. All rights reserved.
//

#import <Cocoa/Cocoa.h>

#import "ServerProtocol.h"

@interface LoginWindowController : NSWindowController

@property (nonatomic, strong) IBOutlet NSTextField *textEmail;
@property (nonatomic, strong) IBOutlet NSTextField *textPassword;
@property (nonatomic, strong) IBOutlet NSTextField *textRepeatPassword;
@property (nonatomic, strong) IBOutlet NSButton *buttonLogin;
@property (nonatomic, strong) IBOutlet NSButton *buttonRegister;

@property (nonatomic, strong) ServerProtocol *serverProtocol;

@end
