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
    // test account alpascualtest
    // password 1234567
    
    //TODO
    BOOL loginSuccess = [self.serverProtocol serverLogin:self.textEmail.stringValue Pasword:self.textPassword.stringValue];
    
    NSLog(@"login works? %c", loginSuccess);
    
    NSUserDefaults *defaults = [NSUserDefaults standardUserDefaults];
    
    if ( loginSuccess == FALSE){
        self.responseText.stringValue = @"Incorrect username or password";
        [defaults removeObjectForKey:UsernameKey];
        [defaults removeObjectForKey:PasswordKey];
    }
    else
    {
        self.responseText.stringValue = @"";
        //TODO Hide the login page
        
        [defaults setObject:self.textEmail.stringValue forKey:UsernameKey];
        [defaults setObject:self.textPassword.stringValue forKey:PasswordKey];
        [defaults synchronize];
    }
    
    [defaults synchronize];
}

- (IBAction) registerPress:(id)sender
{
    self.registrationWindow = [[RegistrationWindowController alloc] initWithWindowNibName:@"RegistrationWindowController"];
    
    [self.registrationWindow showWindow:self];    
    
}

@end
