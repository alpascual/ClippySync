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
    self.serverProtocol = [[ServerProtocol alloc] init];
}


- (IBAction) loginPress:(id)sender
{
    
    //TODO
    BOOL loginSuccess = [self.serverProtocol serverLogin:self.textEmail.stringValue Pasword:self.textPassword.stringValue];
    
    NSLog(@"login works? %c", loginSuccess);
    
    if ( loginSuccess == FALSE)
        self.responseText.stringValue = @"Incorrect username or password";
    else
    {
        self.responseText.stringValue = @"";
        //TODO Hide the login page
    }
        
}

- (IBAction) registerPress:(id)sender
{
    [self.serverProtocol serverRegistration:self.textEmail.value Password:self.textPassword.value];
}

@end
