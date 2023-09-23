#version 330 core

layout (location = 0) in vec3 aPos;

uniform float movement;

out vec3 position;

void main()
{
   gl_Position = vec4(aPos.xyz, 1.0f);
   position = aPos;
}