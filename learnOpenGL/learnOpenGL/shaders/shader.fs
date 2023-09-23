#version 330 core

in vec3 position;

out vec4 FragColor;

void main()
{
   // FragColor = vec4((position.x+1)/2,(position.y+1)/2,(position.z+1)/2, 1.0f);
   FragColor = vec4(position.xyz, 1.0f);
}