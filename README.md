# Amaze Game Demo
## Project Run
###  Unity version 2021.3.19f1 (64-bit)
## Project Build File
### The game's apk is included in the Build file.
##  Original Game Link
### https://play.google.com/store/apps/details?id=com.crazylabs.amaze.game

## Modifications : 
- Added playerprefs to save level before mode switch. Used while game mode switch to appropriate saved level.
- Transition added : Level to Level transition and Initialize to level, used only first one.
- Added co-routines to swap map while transition for smooth map swap (not visible to user/player).
- Added "Background" gameobject to smoothen the transition, else the shadow of maze will create unwanted parallel dark lines in middle of transition.
- Bug fix : Level Completed was not visible, issue fixed: text overflow enable, removed wrap.
- Bug fix : Level Number should be updated regardless of mode change type, issue fixed: moved level updation outside condition, now happens every mode switch regardless of mode type.
- Bug fix : Mode should change only when current mode not equal to new mode, the case of being in a mode and going into same mode was not handeled.
