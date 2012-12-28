//
//  RegistrationWindowController.m
//  ClippyMacClient
//
//  Created by Albert Pascual on 12/24/12.
//  Copyright (c) 2012 Esri. All rights reserved.
//

#import "RegistrationWindowController.h"

@interface RegistrationWindowController ()

@end

@implementation RegistrationWindowController

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

- (IBAction)createAccountPressed:(id)sender
{
    // Verify that passwords are the same
    
    if ( [self.textPassword.stringValue isEqualToString:self.textRepeatPassword.stringValue] == YES)
    {
        
        BOOL bAccountCreated = [self.serverProtocol serverRegistration:self.textEmail.stringValue Password:self.textPassword.stringValue];
        
        NSLog(@"Account created %c", bAccountCreated);
        
        self.labelResponse.stringValue = @"";
        
        //TODO hide and login?
    }
    else
    {
        // Passwords don't match
        self.labelResponse.stringValue = @"Passwords don't match";
    }
}

@end
