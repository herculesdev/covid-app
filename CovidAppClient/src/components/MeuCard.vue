<template>
    <div class="card mb-4">
    <div class="card-body">
        <h6 class="card-title">{{titulo}}</h6>          
        <meu-spinner v-if="ligarSpinner" />   
        <p v-else class="card-text blue-text"><i :class="icone"></i> <span class="ml-2" style="font-size: 30px;">{{conteudo}}</span></p>
    </div>
    </div>
</template>

<script>
import MeuSpinner from './MeuSpinner.vue'

export default {
    components: {
        MeuSpinner
    },
    props: {
        titulo: {}, 
        conteudo: {},
        icone: {}, 
        ligarSpinner: {} 
    }
}
</script>