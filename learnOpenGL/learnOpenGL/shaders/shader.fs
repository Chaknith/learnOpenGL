#version 330 core

out vec4 FragColor;

struct Material{
    vec3 ambient;
    sampler2D diffuse;
    sampler2D specular;
    float shininess;
};

struct Light{
    vec3 direction;
    vec3 position;
    float cutOff;
    float outerCutOff;

    vec3 ambient;
    vec3 diffuse;
    vec3 specular;

    float constant;
    float linear;
    float quadratic;
};

uniform Material material;
uniform Light light;

uniform vec3 viewPos;
uniform vec3 viewFront;

in vec2 TexCoord;

in vec3 Normal;
in vec3 FragPos;

void main()
{
    // caluclate point light
    float distance = length(light.position - FragPos);
    float attenuation = 1.0 / (light.constant + light.linear * distance + light.quadratic * (distance * distance));

    // calculate view and shadow
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(light.position - FragPos); 
    float diff = max(dot(norm, lightDir), 0.0);

    // calculate focal point
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);

    vec3 diffuse = (light.diffuse * diff) * vec3(texture(material.diffuse, TexCoord));
    vec3 ambient = light.ambient * vec3(texture(material.diffuse, TexCoord));
    vec3 specular = light.specular * spec * vec3(texture(material.specular, TexCoord));

  // calculate spotlight
    float theta = dot(lightDir, normalize(-light.direction));
    float epsilon = light.cutOff - light.outerCutOff;
    float intensity = clamp((theta - light.outerCutOff) / epsilon, 0.0, 1.0);

    diffuse *= intensity;
    specular *= intensity;

    FragColor = vec4((ambient + diffuse + specular), 1.0);
}