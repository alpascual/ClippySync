//
//  AppDelegate.h
//  ClippyMacClient
//
//  Created by Al Pascual on 12/12/12.
//  Copyright (c) 2012 Esri. All rights reserved.
//

#import <Cocoa/Cocoa.h>
#import "OptionsWindowController.h"
#import "LoginWindowController.h"

#import "NSDictionary_JSONExtensions.h"

#import "CJSONDeserializer.h"

@interface AppDelegate : NSObject <NSApplicationDelegate>

@property (assign) IBOutlet NSWindow *window;
@property (nonatomic,strong) IBOutlet NSMenu *statusMenu;
@property (nonatomic,strong) NSStatusItem *statusItem;
@property (nonatomic,strong) NSImage *statusImage;
@property (nonatomic,strong) NSImage *statusHighlighImage;
@property (nonatomic,strong) NSTimer *clipboardTimer;
@property (nonatomic) BOOL bPaused;
@property (nonatomic) double lastNumber;

@property (nonatomic,strong) OptionsWindowController *options;
@property (nonatomic,strong) LoginWindowController *login;

- (IBAction)loginPressed:(id)sender;
- (IBAction)pausePressed:(id)sender;
- (IBAction)optionsPressed:(id)sender;


@end
