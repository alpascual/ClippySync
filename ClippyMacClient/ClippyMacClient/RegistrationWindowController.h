//
//  RegistrationWindowController.h
//  ClippyMacClient
//
//  Created by Albert Pascual on 12/24/12.
//  Copyright (c) 2012 Esri. All rights reserved.
//

#import <Cocoa/Cocoa.h>

@interface RegistrationWindowController : NSWindowController

@property (nonatomic, strong) IBOutlet NSTextField *textEmail;
@property (nonatomic, strong) IBOutlet NSTextField *textPassword;
@property (nonatomic, strong) IBOutlet NSTextField *textRepeatPassword;
@property (nonatomic, strong) IBOutlet NSButton *buttonRegister;

@end
