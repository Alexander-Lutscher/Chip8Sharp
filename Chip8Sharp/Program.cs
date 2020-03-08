using System;
using System.IO;
using System.Linq;
using Chip8Sharp.Constants;
using static SDL2.SDL;

namespace Chip8Sharp
{
    class Program
    {
        private Chip8Cpu cpu;

        static void Main(string[] args)
        {
            var app = new Program();
            app.SetupCPU();
            app.SetupWindow();
        }

        public void SetupCPU()
        {
            cpu = new Chip8Cpu();

            var initFile = File.ReadAllText(FilesPath.StartupFile);
            var allPrograms = initFile.Replace("\r\n", "\n").Split("\n");
            var instruction = (new InstructionLoader()).Load(allPrograms.FirstOrDefault());

            cpu.Run(instruction);

        }

        public void SetupWindow()
        {
            SDL_Event e;
            if (SDL_Init(SDL_INIT_VIDEO) < 0)
            {
                Console.WriteLine("Unable to initialize SDL. Error: {0}", SDL_GetError());
            }
            else
            {
                var window = SDL_CreateWindow(".NET Core SDL2-CS Tutorial",
                    SDL_WINDOWPOS_CENTERED,
                    SDL_WINDOWPOS_CENTERED,
                    640,
                    480,
                    SDL_WindowFlags.SDL_WINDOW_RESIZABLE
                );

                if (window == IntPtr.Zero)
                {
                    Console.WriteLine("Unable to create a window. SDL. Error: {0}", SDL_GetError());
                }
                else
                {
                    //SDL.SDL_Delay(5000);

                    var quit = false;

                    while (!quit)
                    {
                        while (SDL_PollEvent(out e) != 0)
                        {
                            switch (e.type)
                            {
                                case SDL_EventType.SDL_QUIT:
                                    quit = true;
                                    break;

                                case SDL_EventType.SDL_KEYDOWN:

                                    switch (e.key.keysym.sym)
                                    {
                                        case SDL_Keycode.SDLK_q:
                                            quit = true;
                                            break;
                                    }

                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                        }
                    }
                }

                SDL_DestroyWindow(window);
                SDL_Quit();
            }
        }
    }
}
