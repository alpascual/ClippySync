//
//  AppDelegate.m
//  ClippyMacClient
//
//  Created by Al Pascual on 12/12/12.
//  Copyright (c) 2012 Esri. All rights reserved.
//

#import "AppDelegate.h"

@implementation AppDelegate

- (void) awakeFromNib
{
    self.statusItem = [[NSStatusBar systemStatusBar] statusItemWithLength:NSVariableStatusItemLength];
    
    NSBundle *bundle = [NSBundle mainBundle];
    
    self.statusImage = [[NSImage alloc] initWithContentsOfFile:[bundle pathForResource:@"sync-image" ofType:@"ico"]];
    self.statusHighlighImage = [[NSImage alloc] initWithContentsOfFile:[bundle pathForResource:@"sync-image" ofType:@"ico"]];
    
    [self.statusItem setImage:self.statusImage];
    [self.statusItem setAlternateImage:self.statusHighlighImage];
    [self.statusItem setMenu:self.statusMenu];
    [self.statusItem setToolTip:@"Sync the clipboard"];
    
}


- (IBAction)loginPressed:(id)sender
{
    
}
- (IBAction)pausePressed:(id)sender
{
    
}
- (IBAction)optionsPressed:(id)sender
{
    
}


@end
