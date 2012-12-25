//
//  LoginWindowController.m
//  ClippyMacClient
//
//  Created by Al Pascual on 12/12/12.
//  Copyright (c) 2012 Esri. All rights reserved.
//

#import "LoginWindowController.h"

@interface LoginWindowController ()

@end

@implementation LoginWindowController

- (id)initWithWindow:(NSWindow *)window
{
    self = [super initWithWindow:window];
    if (self) {
        // Initialization code here.
    }
    
    return self;
}

- (void)windowDidLoad
{
    [super windowDidLoad];
    
    // Implement this method to handle any initialization after your window controller's window has been loaded from its nib file.
    
    [self.buttonLogin setTarget:self];
    [self.buttonLogin setAction:@selector(loginPress:)];
}

- (IBAction) loginPress
{
    //TODO
    [self.serverProtocol serverLogin:self.textEmail.value Pasword:self.textPassword.value];
}

- (IBAction) registerPress
{
    [self.serverProtocol serverRegistration:self.textEmail.value Password:self.textPassword.value];
}

@end
