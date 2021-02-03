<template>
    <div class="container">
        <div class="px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">    
            <h2>Média Móvel Coronavírus</h2>
            <p class="lead">
                Esta aplicação foi desenvolvida como prova técnica para o processo seletivo da Sommus Sistemas e exibe a média móvel dos casos e mortes do coronavírus no Brasil relativos as últimas 3 semanas.
            </p>
            <div class="row mt-3 pt-3">
                <div class="col-md-6">
                    <meu-card titulo="Casos" :conteudo="casos" icone="fas fa-clipboard-list fa-2x" :ligarSpinner="spinner" />
                </div>
                <div class="col-md-6">
                    <meu-card titulo="Mortes" :conteudo="mortes" icone="fas fa-book-dead fa-2x" :ligarSpinner="spinner" />
                </div>
            </div>
            <button class="btn btn-primary" @click="obterCasos()">Atualizar</button>
        </div>
    </div>
</template>

<script>
import moment from 'moment';
import MeuCard from '../components/MeuCard';

export default {
    components: {
        MeuCard
    },
    data: function() {
        return {
            dados: {
                casos: 0,
                mortes: 0
            },
            spinner: true
        }
    },
    methods: {
        obterCasos: function()
        {
            this.spinner = true

            var formatoData = 'yyyy-MM-DD'
            var dataInicial = moment().add(-3,'w').format(formatoData)
            var dataFinal = moment().format(formatoData)

            let url = `https://localhost:5001/casos/media?de=${dataInicial}&ate=${dataFinal}`

            this.axios.get(url).then(response => {
                this.dados = response.data
                this.spinner = false;
            });
        }
    },
    computed: {
        casos: function() {
            return Intl.NumberFormat('en-US', { maximumSignificantDigits: 3 }).format(this.dados.casos)
        },
        mortes: function() {
            return Intl.NumberFormat('en-US', { maximumSignificantDigits: 3 }).format(this.dados.mortes)
        }
    },
    mounted: function()
    {
        this.obterCasos();
    }
}
</script>