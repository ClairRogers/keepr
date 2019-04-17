<template>
  <div class="Vault container">
    <div class="d-flex flex-row justify-content-between">
      <h2 class="pointer" @click="goBack"><i class="fas fa-chevron-left"></i></h2>
      <h1>{{activeVault.name}}</h1>
      <span></span>
    </div>
    <div class="card-columns">
      <div v-for="vaultkeep in vaultkeeps" class="card pointer" @click="setActiveKeep(keep)" data-toggle="modal"
        data-target=".bd-example-modal-lg">
        <img :src="vaultkeep.img" class="card-img-top">
        <div class="card-body">
          <p class="card-text">{{vaultkeep.name}}<span class="ml-2 opaque" v-if="vaultkeep.isPrivate == true"
              title="Private"><i class="fas fa-lock"></i></span>
          </p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  import router from '@/router.js'
  export default {
    name: "Vault",
    props: [],
    data() {
      return {}
    },
    computed: {
      activeVault() {
        return this.$store.state.activeVault
      },
      vaultkeeps() {
        return this.$store.state.vaultKeeps
      }
    },
    methods: {
      goBack() {
        router.push({ name: "dashboard" })
      }
    },
    components: {}
  }
</script>