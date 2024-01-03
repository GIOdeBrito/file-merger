







class Imagem
{
	constructor() {}

	static async buscarImagemURL ()
	{
		return new Promise((resolve, reject) =>
		{
			fetch(link).then(async (res) =>
			{
				const img_blob = await res.blob();
				resolve(await URL.createObjectURL(img_blob));
			})
			.catch((erro) =>
			{
				console.error(`! ERRO AO BUSCAR: ${link} !`);
				console.error(erro);
				reject(erro);
			});
		});
	}

	static mudarCorPapel (cor = Number(0))
	{
		let papelFD = Global.Elementos.papelIcone;
		let papel_cores_fundo = [
			"255,255,255",
			"150,150,150",
			"222,203,164",
		];

		papelFD.style.backgroundColor = `rgb(${papel_cores_fundo[cor]})`;
		Global.Variaveis.papelCor = cor;

		Renderizar.renderizar();
	}

	static corPrincipal (tela, ctx)
	{
		var img = ctx.getImageData(0,0,tela.width,tela.height);
		var imgDados = img.data;
		var cores = new Array();

		

		for(let i = 0; i < imgDados.length; i+=4)
		{
			let r = imgDados[i], g = imgDados[i+1], b = imgDados[i+2];
			let rgb = `r=${r}g=${g}b=${b}`;
			const index = cores.findIndex(cor => cor.hex == rgb);

			if(index >= 0)
			{
				cores[index].num += 1;
				continue;
			}

			cores.push({ hex: rgb, num: 1 });
		}

		
		cores.sort((a, b) =>
		{
			
			return b.num - a.num;
		});

		if(cores[0].hex != Global.Variaveis.corMaisFrequente)
		{
			Global.Variaveis.corMaisFrequente = cores[0].hex;
			return false;
		}

		return true;
	}
}











function neopagina (pg = 1)
{
	Global.Obra.setAtualPagina = pg;

	if(Global.Obra.AtualPagina >= Global.Obra.TotalPaginas)
	{
		Global.Obra.setAtualPagina = Global.Obra.TotalPaginas;
	}

	if(Global.Obra.AtualPagina <= 1)
	{
		Global.Obra.setAtualPagina = 1;
	}

	const marcar = (Global.Obra.AtualPagina == Global.Variaveis.salva ? true : false);
	
	mostrarIconeMarcaPaginas(marcar);

	
	if(Global.Booleanos.borrar_pagina)
	{
		Global.Booleanos.borrar_pagina = false;
	}

	
	Renderizar.renderizar({ alt: true, redef: true });
}


