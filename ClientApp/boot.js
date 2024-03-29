
// import 'bootstrap';
import Vue from 'vue';
import VueRouter from 'vue-router';
import BootstrapVue from 'bootstrap-vue';



Vue.use(VueRouter);
Vue.use(BootstrapVue);

const routes = [
   
];

new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app.vue'))
});
