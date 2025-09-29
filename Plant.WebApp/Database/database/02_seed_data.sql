INSERT INTO [dbo].[Plantas] (
    Nombre,
    NombreCientifico,
    Origen,
    Descripcion,
    CuidadosBasicos,
    ClimaIdeal,
    Floracion,
    AlturaMaxima,
    ImagenUrl
)
VALUES
-- 1
('Orquídea mariposa', 'Phalaenopsis amabilis', 'Sudeste Asiático',
 'Orquídea muy cultivada por sus flores grandes y vistosas.',
 'Riego moderado, luz indirecta, ambiente húmedo.',
 'Tropical húmedo', 'Invierno - Primavera', '0.5 m',
 'https://i0.wp.com/www.mardeflores.com/wp-content/uploads/2023/04/20250218_130122_rodano_3.jpg'),

-- 2
('Cactus de Navidad', 'Schlumbergera truncata', 'Brasil',
 'Cactus epífito que florece en invierno con colores brillantes.',
 'Riego moderado, sombra parcial, no tolera sequías largas.',
 'Subtropical húmedo', 'Invierno', '0.4 m',
 'https://content.elmueble.com/medio/2020/11/27/cactus-de-navidad_7f63003e_674x446.jpg'),

-- 3
('Lavanda', 'Lavandula angustifolia', 'Mediterráneo',
 'Planta aromática con flores violetas, usada en perfumes y aceites.',
 'Pleno sol, riego moderado, suelo bien drenado.',
 'Mediterráneo seco', 'Verano', '0.8 m',
 'https://cdn.shopify.com/s/files/1/0272/1392/2339/files/Lavanda-dentata_22o_rhodes_comprar-plantas-online_plantas-de-interior.jpg?v=1689089861'),

-- 4
('Rosal', 'Rosa spp.', 'Asia y Europa',
 'Arbusto ornamental muy popular, con flores de múltiples colores.',
 'Sol directo, riego frecuente, poda regular.',
 'Templado', 'Primavera - Otoño', '2.0 m',
 'https://cdn.shopify.com/s/files/1/0272/1392/2339/files/Como-cuidar-rosal-2.jpg?v=1676029561'),

-- 5
('Girasol', 'Helianthus annuus', 'América del Norte',
 'Planta alta con flores grandes que siguen la dirección del sol.',
 'Pleno sol, riego regular, suelos fértiles.',
 'Templado cálido', 'Verano', '3.0 m',
 'https://upload.wikimedia.org/wikipedia/commons/a/a9/A_sunflower.jpg');
GO
