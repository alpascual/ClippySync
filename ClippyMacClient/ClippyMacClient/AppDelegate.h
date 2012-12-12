//
//  AppDelegate.h
//  ClippyMacClient
//
//  Created by Al Pascual on 12/12/12.
//  Copyright (c) 2012 Esri. All rights reserved.
//

#import <Cocoa/Cocoa.h>
#import "OptionsWindowController.h"

@interface AppDelegate : NSObject <NSApplicationDelegate>

@property (assign) IBOutlet NSWindow *window;
@property (nonatomic,strong) IBOutlet NSMenu *statusMenu;
@property (nonatomic,strong) NSStatusItem *statusItem;
@property (nonatomic,strong) NSImage *statusImage;
@property (nonatomic,strong) NSImage *statusHighlighImage;
@property (nonatomic,strong) OptionsWindowController *options;

- (IBAction)loginPressed:(id)sender;
- (IBAction)pausePressed:(id)sender;
- (IBAction)optionsPressed:(id)sender;


@end
