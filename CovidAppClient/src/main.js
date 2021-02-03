import Vue from 'vue'
import App from './App.vue'
import Axios from 'axios'
import VueAxios from 'vue-axios'

Vue.use(VueAxios, Axios)

Vue.config.productionTip = false

new Vue({
    render: h => h(App),
}).$mount('#app')