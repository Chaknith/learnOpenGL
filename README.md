# learnOpenGL

## Set up GFLW and GLAD with Visual Studio

```
Libraries
├── include
│   ├── glad      // glad include folder
│   ├── KHR       // glad include folder
│   └── GFLW      // gflw include folder
├── lib
│   └── gflw3.lib // gflw lib file
└── glad.c        // Not necessary just trying to keep required resources in one place
```

### In Visual Studio
- Right-click on project -> Properties -> Linker
  - General -> Additional Library Directories -> input "Libraries\lib"
  - Input -> Additional Dependencies -> input "gflw3.lib;opengl32.lib;"
- C/C++
  - General -> Additional Include Directories -> input "Libraries\include"

#### Include .c and .lib files in the project
- Right-click on project -> Add -> Add Existing item...
  - Add glad.c
  - Add gflw3.lib

Visual Studio will not automatically recognize the files with simply drag and drop.
