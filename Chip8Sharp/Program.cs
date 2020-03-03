﻿using System;
using SDL2;

namespace Chip8Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) < 0)
            {
                Console.WriteLine("Unable to initialize SDL. Error: {0}", SDL.SDL_GetError());
            }
            else
            {
                IntPtr window;
                window = SDL.SDL_CreateWindow(".NET Core SDL2-CS Tutorial",
                    SDL.SDL_WINDOWPOS_CENTERED,
                    SDL.SDL_WINDOWPOS_CENTERED,
                    640,
                    480,
                    SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE
                );

                if (window == IntPtr.Zero)
                {
                    Console.WriteLine("Unable to create a window. SDL. Error: {0}", SDL.SDL_GetError());
                }
                else
                {
                    //SDL.SDL_Delay(5000);

                    bool quit = false;

                    SDL.SDL_Event e;

                    while (!quit)
                    {
                        while (SDL.SDL_PollEvent(out e) != 0)
                        {
                            switch (e.type)
                            {
                                case SDL.SDL_EventType.SDL_QUIT:
                                    quit = true;
                                    break;

                                case SDL.SDL_EventType.SDL_KEYDOWN:

                                    switch (e.key.keysym.sym)
                                    {
                                        case SDL.SDL_Keycode.SDLK_q:
                                            quit = true;
                                            break;
                                    }

                                    break;
                            }
                        }
                    }
                }

                SDL.SDL_DestroyWindow(window);
                SDL.SDL_Quit();
            }
        }
    }
}
